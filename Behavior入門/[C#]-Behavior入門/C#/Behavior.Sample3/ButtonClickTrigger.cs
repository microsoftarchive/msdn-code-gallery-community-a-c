namespace Behavior.Sample3
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    /// <summary>
    /// Triggerを作成するにはTriggerBaseを継承する。
    /// ジェネリックパラメータには、Triggerを置けるコントロールを指定する。
    /// </summary>
    public class ButtonClickTrigger : TriggerBase<Button>
    {
        // OnAttachedとOnDetachingは、Behaviorと同じように作る。
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Click += this.Button_Click;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.Button_Click;
            base.OnDetaching();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // 子要素のActionを実行する。
            this.InvokeActions(e);
        }
    }
}
