        /// <summary>
        /// Verify google payment.
        /// </summary>
        /// <remarks>
        /// - http://petr.logdown.com/posts/255755-automatic-apk-upload-1
        /// - https://developers.google.com/api-client-library/dotnet/apis/androidpublisher/v1
        /// - https://groups.google.com/forum/#!msg/google-api-dotnet-client/fYDU_dAv30g/Jhd_4Lr5oYMJ
        /// </remarks>
        public PaymentResult VerifyPayment(PaymentGoogleData data, int productId)
        {
            // Convert app product id into Google's IAP first.
            string productKey = string.Empty;
            googleProductIdKeyMap.TryGetValue(productId, out productKey);
            if (string.IsNullOrEmpty(productKey))
            {
                // [IK]: debugging throw new DomainException("Cannot find Google product key for product id " + productId + ".");
                return PaymentResult.ErrorUnknown;
            }

            // Prepare credentials for Google Pay service. Authorize.
            using (var certificate = new X509Certificate2(
                    GetCertificateRawData(GOOGLE_SERVICE_PRIVATE_KEY_NAME),
                    GOOGLE_SERVICE_PRIVATE_KEY_PASSWORD,
                    X509KeyStorageFlags.Exportable))
            {
                var credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(GOOGLE_SERVICE_ACCOUNT_EMAIL)
                    {
                        Scopes = new[] { AndroidPublisherService.Scope.Androidpublisher }
                    }.FromCertificate(certificate));

                var productPurchase = GetProductPurchase(credential, productKey, data.PaymentToken);
                return productPurchase == null
                    ? PaymentResult.ErrorUnknown
                    : PaymentResult.Success;
            }
        }

        /// <summary>
        /// Get certificate as binary.
        /// </summary>
        /// <param name="resourceName">Name of resource.</param>
        /// <returns>The raw certificate.</returns>
        private byte[] GetCertificateRawData(string resourceName)
        {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("App_Data." + resourceName))
            {
                using (var streamReader = new System.IO.BinaryReader(stream))
                {
                    return streamReader.ReadBytes((int)stream.Length);
                }
            }
        }

        /// <summary>
        /// Get Product purchase.
        /// </summary>
        /// <param name="credential">Service account credential.</param>
        /// <param name="productKey">Google product key.</param>
        /// <param name="token">Google payment token.</param>
        /// <returns>The raw certificate.</returns>
        private ProductPurchase GetProductPurchase(ServiceAccountCredential credential, string productKey, string token)
        {
            using (var service = new AndroidPublisherService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = APP_NAME,
                }))
            {
                var response = service.Purchases.Products.Get(APP_PACKAGE_NAME, productKey, token);
                return response.Execute();
            }
        }
    }
