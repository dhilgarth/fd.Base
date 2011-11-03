using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using Autofac;

namespace fd.Base.AutofacMvc
{
    public class AutofacMembershipProvider : MembershipProvider
    {
        private MembershipProvider _realProvider;

        public override string ApplicationName
        {
            get { return _realProvider.ApplicationName; }
            set { _realProvider.ApplicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return _realProvider.EnablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return _realProvider.EnablePasswordRetrieval; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return _realProvider.MaxInvalidPasswordAttempts; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _realProvider.MinRequiredNonAlphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return _realProvider.MinRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow
        {
            get { return _realProvider.PasswordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _realProvider.PasswordFormat; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return _realProvider.PasswordStrengthRegularExpression; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return _realProvider.RequiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return _realProvider.RequiresUniqueEmail; }
        }

        public T GetRealProvider<T>() where T : MembershipProvider
        {
            return (T) _realProvider;
        }

        public IComponentContext GetContainer()
        {
            var context = GetHttpContext();
            var provider = context.ApplicationInstance as IContainerProvider;
            if (provider == null)
                throw new Exception("The global HttpApplication instance needs to implement " + typeof (IContainerProvider).FullName);
            return provider.Get();
        }

        private static HttpContext GetHttpContext()
        {
            var context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException("No HttpContext");
            return context;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            var realProviderTypeName = config["realProviderType"];
            if (string.IsNullOrWhiteSpace(realProviderTypeName))
                throw new Exception("Please configure the providerId from the membership provider " + name);
            Type realProviderType = null;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                realProviderType = assembly.GetType(realProviderTypeName);
                if (realProviderType != null)
                    break;
            }
            if (realProviderType == null)
            {
                throw new TypeLoadException("The type '" + realProviderTypeName + "' could not be found. "
                                            + "Please make sure that either the type name is a fully qualified type name including assembly or "
                                            + "it is located in one of the referenced assemblies.");
            }

            if (!typeof (MembershipProvider).IsAssignableFrom(realProviderType))
                throw new InvalidOperationException("The specified type '" + realProviderType.FullName + "' doesn't derive from MembershipProvider.");

            var container = GetContainer();
            if (!container.IsRegistered(realProviderType))
            {
                throw new InvalidOperationException("The type '" + realProviderType.FullName + "' couldn't be resolved in the DI container. "
                                                    + "Please make sure it is registered with that exact type.");
            }
            _realProvider = (MembershipProvider) container.Resolve(realProviderType);
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
                bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return _realProvider.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return _realProvider.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
        }

        public override string GetPassword(string username, string answer)
        {
            return _realProvider.GetPassword(username, answer);
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _realProvider.ChangePassword(username, oldPassword, newPassword);
        }

        public override string ResetPassword(string username, string answer)
        {
            return _realProvider.ResetPassword(username, answer);
        }

        public override void UpdateUser(MembershipUser user)
        {
            _realProvider.UpdateUser(user);
        }

        public override bool ValidateUser(string username, string password)
        {
            return _realProvider.ValidateUser(username, password);
        }

        public override bool UnlockUser(string userName)
        {
            return _realProvider.UnlockUser(userName);
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return _realProvider.GetUser(providerUserKey, userIsOnline);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return _realProvider.GetUser(username, userIsOnline);
        }

        public override string GetUserNameByEmail(string email)
        {
            return _realProvider.GetUserNameByEmail(email);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return _realProvider.DeleteUser(username, deleteAllRelatedData);
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return _realProvider.GetAllUsers(pageIndex, pageSize, out totalRecords);
        }

        public override int GetNumberOfUsersOnline()
        {
            return _realProvider.GetNumberOfUsersOnline();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return _realProvider.FindUsersByEmail(usernameToMatch, pageIndex, pageSize, out totalRecords);
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return _realProvider.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
        }
    }
}
