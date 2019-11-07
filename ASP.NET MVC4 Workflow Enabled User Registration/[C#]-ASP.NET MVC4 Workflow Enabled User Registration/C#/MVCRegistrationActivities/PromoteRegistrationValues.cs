using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace MVCRegistrationActivities
{

    public sealed class PromoteRegistrationValues : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Email { get; set; }

        [RequiredArgument]
        public InArgument<string> UserName { get; set; }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.RequireExtension<RegistrationPeristenceParticipant>();
            base.CacheMetadata(metadata);
        }

        protected override void Execute(CodeActivityContext context)
        {
            var regParticipant = context.GetExtension<RegistrationPeristenceParticipant>();

            regParticipant.UserName = this.UserName.Get(context);
            regParticipant.Email = this.Email.Get(context);
        }
    }
}
