namespace MVCRegistrationActivities
{
    using System;
    using System.Activities;
    using System.Web.Security;

    public sealed class ApproveMembership : CodeActivity
    {
        #region Public Properties

        [RequiredArgument]
        public InArgument<string> UserName { get; set; }

        #endregion

        #region Methods

        protected override void Execute(CodeActivityContext context)
        {
            var user = Membership.GetUser(this.UserName.Get(context));
            if (user == null)
            {
                throw new InvalidOperationException("Cannot find user");
            }

            user.IsApproved = true;
            Membership.UpdateUser(user);
        }

        #endregion
    }
}