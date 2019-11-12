using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace MVCRegistrationActivities
{

    public sealed class WaitForCommand : NativeActivity<object>
    {
        // Define an activity input argument of type string
        public InArgument<RegistrationCommand> Command { get; set; }

        /// <summary>
        /// When implemented in a derived class, runs the activity’s execution logic.
        /// </summary>
        /// <param name="context">The execution context in which the activity executes.</param>
        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(this.Command.Get(context).ToString(), (activityContext, bookmark, value) => activityContext.SetValue(this.Result, value));

        }

        /// <summary>
        ///   Gets a value indicating whether CanInduceIdle.
        /// </summary>
        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }


    }
}
