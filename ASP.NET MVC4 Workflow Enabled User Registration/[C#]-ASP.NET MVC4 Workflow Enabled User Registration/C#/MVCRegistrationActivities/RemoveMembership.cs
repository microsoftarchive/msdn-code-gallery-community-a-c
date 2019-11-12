using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace MVCRegistrationActivities
{
    using System.Web.Security;

    public sealed class RemoveMembership : CodeActivity
    {
        public InArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Membership.DeleteUser(Text.Get(context));
        }
    }
}
