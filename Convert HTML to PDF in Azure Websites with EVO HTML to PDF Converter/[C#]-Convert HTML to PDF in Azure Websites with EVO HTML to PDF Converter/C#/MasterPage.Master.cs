using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvoHtmlToPdfDemo
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void CollapseAll()
        {
            demoTreeView.Nodes[0].Collapse();
            demoTreeView.Nodes[1].Collapse();
            demoTreeView.Nodes[2].Collapse();
            demoTreeView.Nodes[3].Collapse();
        }

        public void ExpandAll()
        {
            demoTreeView.Nodes[0].Expand();
            demoTreeView.Nodes[1].Expand();
            demoTreeView.Nodes[2].Expand();
            demoTreeView.Nodes[3].Expand();
        }

        public void ExpandNode(string nodeValue)
        {
            ExpandNodeRecursive(demoTreeView.Nodes, nodeValue);
        }

        private bool ExpandNodeRecursive(TreeNodeCollection nodesCollection, string nodeValue)
        {
            if (nodesCollection == null)
                return false;

            if (nodesCollection.Count == 0)
                return false;

            foreach (TreeNode treeNode in nodesCollection)
            {
                if (treeNode.Value == nodeValue)
                {
                    treeNode.Expand();
                    return true;
                }
                else if (ExpandNodeRecursive(treeNode.ChildNodes, nodeValue))
                    return true;
            }

            return false;
        }

        public void CollapseNode(string nodeValue)
        {
            CollapseNodeRecursive(demoTreeView.Nodes, nodeValue);
        }

        private bool CollapseNodeRecursive(TreeNodeCollection nodesCollection, string nodeValue)
        {
            if (nodesCollection == null)
                return false;

            if (nodesCollection.Count == 0)
                return false;

            foreach (TreeNode treeNode in nodesCollection)
            {
                if (treeNode.Value == nodeValue)
                {
                    treeNode.Collapse();
                    return true;
                }
                else if (CollapseNodeRecursive(treeNode.ChildNodes, nodeValue))
                    return true;
            }

            return false;
        }

        public void SelectNode(string nodeValue)
        {
            SelectNodeRecursive(demoTreeView.Nodes, nodeValue);
        }

        private bool SelectNodeRecursive(TreeNodeCollection nodesCollection, string nodeValue)
        {
            if (nodesCollection == null)
                return false;

            if (nodesCollection.Count == 0)
                return false;

            foreach (TreeNode treeNode in nodesCollection)
            {
                if (treeNode.Value == nodeValue)
                {
                    treeNode.Selected = true;
                    return true;
                }
                else if (SelectNodeRecursive(treeNode.ChildNodes, nodeValue))
                    return true;
            }

            return false;
        }

        protected void collapseAllLinkButton_Click(object sender, EventArgs e)
        {
            CollapseAll();
        }

        protected void expandAllLinkButton_Click(object sender, EventArgs e)
        {
            ExpandAll();
        }

        protected void collapseAllImageButton_Click(object sender, ImageClickEventArgs e)
        {
            CollapseAll();
        }

        protected void expandAllImageButton_Click(object sender, ImageClickEventArgs e)
        {
            ExpandAll();
        }
    }
}