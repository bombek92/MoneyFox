using System;
using System.Threading.Tasks;
using Microsoft.OneDrive.Sdk;
using MoneyFox.Foundation.Constants;
using MoneyFox.Foundation.Exceptions;
using MoneyFox.Foundation.Interfaces;

namespace MoneyFox.Ios.OneDriveAuth
{
    public class OneDriveAuthenticator : IOneDriveAuthenticator
    {
        /// <summary>
        ///     Perform an async Login Request
        /// </summary>
        public Task<IOneDriveClient> LoginAsync()
        {
            try
            {
                var tcs = new TaskCompletionSource<IOneDriveClient>();

                tcs.SetResult(new OneDriveClient(ServiceConstants.BASE_URL, new IosAuthenticationProvider()));

                return tcs.Task;
            }
            catch (Exception)
            {
                throw new BackupException("Authentication Failed");
            }
        }

        /// <summary>
        ///     Perform an async Logout Request
        /// </summary>
        public Task LogoutAsync()
        {
            var tcs = new TaskCompletionSource<bool>();
			new IosAuthenticationProvider().Logout();
            return tcs.Task;
        }
    }
}