using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Browser
{
    public partial class frmSearch : Form
    {
        frmMain _Parent = null;
        TreeView _LibraryClassTreeView = null;
        TreeView _MethodPropertyFieldTreeView = null;
        List<Library> _Libraries = null;

        // Constructor
        public frmSearch(frmMain Parent, List<Library> Libraries, TreeView LibraryClassTreeView, TreeView MethodPropertyFieldTreeView)
        {
            InitializeComponent();

            _Parent = Parent;
            _Libraries = Libraries;
            _LibraryClassTreeView = LibraryClassTreeView;
            _MethodPropertyFieldTreeView = MethodPropertyFieldTreeView;
        }

        private void chkLibraries_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkProperties.Checked & !chkFields.Checked & !chkMethods.Checked & !chkClasses.Checked & !chkAnnotations.Checked & !chkParameters.Checked)
            {
                chkLibraries.Checked = true;
            }
        }

        private void chkAnnotations_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkProperties.Checked & !chkFields.Checked & !chkMethods.Checked & !chkClasses.Checked & !chkLibraries.Checked & !chkParameters.Checked)
            {
                chkAnnotations.Checked = true;
            }
        }

        private void chkClasses_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkProperties.Checked & !chkFields.Checked & !chkMethods.Checked & !chkLibraries.Checked & !chkAnnotations.Checked & !chkParameters.Checked)
            {
                chkClasses.Checked = true;
            }
        }

        private void chkMethods_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkProperties.Checked & !chkFields.Checked & !chkClasses.Checked & !chkLibraries.Checked & !chkAnnotations.Checked & !chkParameters.Checked)
            {
                chkMethods.Checked = true;
            }
        }

        private void chkProperties_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMethods.Checked & !chkFields.Checked & !chkClasses.Checked & !chkLibraries.Checked & !chkAnnotations.Checked & !chkParameters.Checked)
            {
                chkProperties.Checked = true;
            }
        }

        private void chkFields_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkProperties.Checked & !chkMethods.Checked & !chkClasses.Checked & !chkLibraries.Checked & !chkAnnotations.Checked & !chkParameters.Checked)
            {
                chkFields.Checked = true;
            }
        }

        //private void chkComments_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (!chkProperties.Checked & !chkFields.Checked & !chkMethods.Checked & !chkClasses.Checked & !chkLibraries.Checked & !chkAnnotations.Checked & !chkParameters.Checked)
        //    {
        //        chkComments.Checked = true;
        //    }
        //}

        private void chkParameters_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkProperties.Checked & !chkFields.Checked & !chkMethods.Checked & !chkClasses.Checked & !chkLibraries.Checked & !chkAnnotations.Checked)
            {
                chkParameters.Checked = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tvwResults.BeginUpdate();
            tvwResults.Nodes.Clear();

            foreach (Library SelectedLibrary in _Libraries)
            {
                if (chkLibraries.Checked)
                {
                    if (SelectedLibrary.Name.ToLower().Contains(txtSearchText.Text.ToLower()))
                    {
                        AddToTreeview(SelectedLibrary);
                    }
                }
                foreach (Class SelectedClass in SelectedLibrary.Classes)
                {
                    if (chkClasses.Checked)
                    {
                        //if (SelectedClass.Name.ToLower().Contains(txtSearchText.Text.ToLower()) | SelectedClass.Comments.Text.ToLower().Contains(txtSearchText.Text.ToLower()))
                        //{
                        //    AddToTreeview(SelectedClass);
                        //}
                    }
                    if (chkMethods.Checked)
                    {
                        foreach (Method SelectedMethod in SelectedClass.Methods)
                        {
                            //if (SelectedMethod.Name.ToLower().Contains(txtSearchText.Text.ToLower()) | SelectedMethod.Comments.Text.ToLower().Contains(txtSearchText.Text.ToLower()))
                            //{
                            //    AddToTreeview(SelectedMethod);
                            //}
                        }
                    }

                    if (chkParameters.Checked)
                    {
                        foreach (Method SelectedMethod in SelectedClass.Methods)
                        {
                            foreach (Parameter SelectedParameter in SelectedMethod.Parameters)
                            {
                                if (SelectedParameter.Name.ToLower().Contains(txtSearchText.Text.ToLower()))
                                {
                                    AddToTreeview(SelectedParameter);
                                }
                            }
                        }
                    }

                    if (chkProperties.Checked)
                    {
                        foreach (Property SelectedProperty in SelectedClass.Properties)
                        {
                            //if (SelectedProperty.Name.ToLower().Contains(txtSearchText.Text.ToLower()) | SelectedProperty.Comments.Text.ToLower().Contains(txtSearchText.Text.ToLower()))
                            //{
                            //    AddToTreeview(SelectedProperty);
                            //}
                        }
                    }

                    if (chkFields.Checked)
                    {
                        foreach (Field SelectedField in SelectedClass.Fields)
                        {
                            //if (SelectedField.Name.ToLower().Contains(txtSearchText.Text.ToLower()) | SelectedField.Comments.Text.ToLower().Contains(txtSearchText.Text.ToLower()))
                            //{
                            //    AddToTreeview(SelectedField);
                            //}
                        }
                    }

                    if (chkAnnotations.Checked)
                    {
                        foreach (Annotation SelectedAnnotation in SelectedClass.Annotations)
                        {
                            if (SelectedAnnotation.Name.ToLower().Contains(txtSearchText.Text.ToLower()) | SelectedAnnotation.Value.ToLower().Contains(txtSearchText.Text.ToLower()))
                            {
                                AddToTreeview(SelectedAnnotation);
                            }
                        }
                    }
                }
            }
            tvwResults.Sort();
            tvwResults.EndUpdate();
        }

        private TreeNode AddToTreeview(Library SelectedLibrary)
        {
            TreeNode[] SearchResults; // = new TreeNode();
            TreeNode LibraryNode = null;

            SearchResults = tvwResults.Nodes.Find(TypeName(SelectedLibrary.Name), false);

            if (SearchResults.Count() > 0)
            {
                LibraryNode = SearchResults[0];
            }
            else
            {
                LibraryNode = new TreeNode();
                LibraryNode.ImageIndex = 3;
                LibraryNode.SelectedImageIndex = 3;
                LibraryNode.Text = TypeName(SelectedLibrary.Name);
                LibraryNode.Name = TypeName(SelectedLibrary.Name);
                LibraryNode.Tag = SelectedLibrary;

                tvwResults.Nodes.Add(LibraryNode);
            }

            return LibraryNode;
        }

        private TreeNode AddToTreeview(Class SelectedClass)
        {
            TreeNode[] SearchResults;
            TreeNode LibraryNode = AddToTreeview(SelectedClass.Parent);  // Adds or finds the Library node
            TreeNode ClassNode = null;

            SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedClass.Name), false);

            if (SearchResults.Count() > 0)
            {
                ClassNode = SearchResults[0];
            }
            else
            {
                ClassNode = new TreeNode();
                ClassNode.ImageIndex = 0;
                ClassNode.SelectedImageIndex = 0;
                ClassNode.Text = TypeName(SelectedClass.Name);
                ClassNode.Name = TypeName(SelectedClass.Name);
                ClassNode.Tag = SelectedClass;

                LibraryNode.Nodes.Add(ClassNode);
            }

            return ClassNode;
        }

        private TreeNode AddToTreeview(Method SelectedMethod)
        {
            TreeNode[] SearchResults;
            TreeNode LibraryNode = AddToTreeview(SelectedMethod.Parent);  // Adds or finds the Library node
            TreeNode MethodNode = null;

            SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedMethod.Name), false);

            if (SearchResults.Count() > 0)
            {
                MethodNode = SearchResults[0];
            }
            else
            {
                MethodNode = new TreeNode();
                MethodNode.ImageIndex = 2;
                MethodNode.SelectedImageIndex = 2;
                MethodNode.Text = TypeName(SelectedMethod.Name);
                MethodNode.Name = TypeName(SelectedMethod.Name);
                MethodNode.Tag = SelectedMethod;

                LibraryNode.Nodes.Add(MethodNode);
            }

            return MethodNode;
        }

        private TreeNode AddToTreeview(Annotation SelectedAnnotation)
        {
            TreeNode[] SearchResults;
            TreeNode LibraryNode = AddToTreeview(SelectedAnnotation.Parent);  // Adds or finds the Library node
            TreeNode AnnotationNode = null;

            SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedAnnotation.Name), false);

            if (SearchResults.Count() > 0)
            {
                AnnotationNode = SearchResults[0];
            }
            else
            {
                AnnotationNode = new TreeNode();
                AnnotationNode.ImageIndex = 6;
                AnnotationNode.SelectedImageIndex = 6;
                AnnotationNode.Text = TypeName(SelectedAnnotation.Name);
                AnnotationNode.Name = TypeName(SelectedAnnotation.Name);
                AnnotationNode.Tag = SelectedAnnotation;

                LibraryNode.Nodes.Add(AnnotationNode);
            }

            return AnnotationNode;
        }

        private TreeNode AddToTreeview(Parameter SelectedParameter)
        {
            TreeNode[] SearchResults;
            TreeNode LibraryNode = AddToTreeview(SelectedParameter.Parent.Parent.Parent);  // Adds or finds the Library node
            TreeNode ParameterNode = null;

            TreeNode ClassNode = AddToTreeview(SelectedParameter.Parent.Parent);           // Adds or finds the Class node
            TreeNode MethodNode = AddToTreeview(SelectedParameter.Parent);                 // Adds or finds the Method node

            SearchResults = MethodNode.Nodes.Find(TypeName(SelectedParameter.Parent.Name), false);  // Methodname

            if (SearchResults.Count() > 0)
            {
                ParameterNode = SearchResults[0];
            }
            else
            {
                ParameterNode = new TreeNode();
                ParameterNode.ImageIndex = 5;
                ParameterNode.SelectedImageIndex = 5;
                ParameterNode.Text = TypeName(SelectedParameter.Name);
                ParameterNode.Name = TypeName(SelectedParameter.Name);
                ParameterNode.Tag = SelectedParameter;

                MethodNode.Nodes.Add(ParameterNode);
            }

            return ParameterNode;
        }

        private TreeNode AddToTreeview(Property SelectedProperty)
        {
            TreeNode[] SearchResults;
            TreeNode LibraryNode = AddToTreeview(SelectedProperty.Parent);  // Adds or finds the Library node
            TreeNode PropertyNode = null;

            SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedProperty.Name), false);

            if (SearchResults.Count() > 0)
            {
                PropertyNode = SearchResults[0];
            }
            else
            {
                PropertyNode = new TreeNode();
                PropertyNode.ImageIndex = 4;
                PropertyNode.SelectedImageIndex = 4;
                PropertyNode.Text = TypeName(SelectedProperty.Name);
                PropertyNode.Name = TypeName(SelectedProperty.Name);
                PropertyNode.Tag = SelectedProperty;

                LibraryNode.Nodes.Add(PropertyNode);
            }

            return PropertyNode;
        }

        private TreeNode AddToTreeview(Field SelectedField)
        {
            TreeNode[] SearchResults;
            TreeNode LibraryNode = AddToTreeview(SelectedField.Parent);  // Adds or finds the Library node
            TreeNode FieldNode = null;

            SearchResults = LibraryNode.Nodes.Find(TypeName(SelectedField.Name), false);

            if (SearchResults.Count() > 0)
            {
                FieldNode = SearchResults[0];
            }
            else
            {
                FieldNode = new TreeNode();
                FieldNode.ImageIndex = 1;
                FieldNode.SelectedImageIndex = 1;
                FieldNode.Text = TypeName(SelectedField.Name);
                FieldNode.Name = TypeName(SelectedField.Name);
                FieldNode.Tag = SelectedField;

                LibraryNode.Nodes.Add(FieldNode);
            }

            return FieldNode;
        }

        private string TypeName(string OriginalTypename)
        {
            string ReturnTypeName = OriginalTypename;

            if (!IsNumeric(OriginalTypename))
            {
                if (!Properties.Settings.Default.ShowFullTypeName)
                {
                    if (OriginalTypename.IndexOf(".") > 0)
                        // shorten the typename
                        ReturnTypeName = OriginalTypename.Substring(OriginalTypename.LastIndexOf(".") + 1);
                }
            }

            return ReturnTypeName;
        }

        public static bool IsNumeric(string StringToTest)
        {
            int i;
            float f;
            decimal d;

            return int.TryParse(StringToTest, out i) ||
            float.TryParse(StringToTest, out f) ||
            decimal.TryParse(StringToTest, out d);
        }

        private TreeNode FindLibraryNode(TreeView Tree, Library TreeTag)
        {
            foreach (TreeNode SearchNode in _LibraryClassTreeView.Nodes)
            {
                if (SearchNode.Tag == TreeTag)
                {
                    SearchNode.Expand();
                    _LibraryClassTreeView.SelectedNode = SearchNode;

                    _Parent.SelectLibraryOrClassTreeNode();

                    return SearchNode;
                }
            }
            return null;
        }

        private TreeNode FindClassNode(TreeNode StartingNode, Class TreeTag)
        {
            foreach (TreeNode SearchNode in StartingNode.Nodes)
            {
                if (SearchNode.Tag == TreeTag)
                {
                    SearchNode.Expand();
                    _LibraryClassTreeView.SelectedNode = SearchNode;

                    _Parent.SelectLibraryOrClassTreeNode();

                    return SearchNode;
                }
            }

            return null;
        }

        private TreeNode FindMethodNode(TreeView Tree, Method TreeTag)
        {
            foreach (TreeNode SearchNode in Tree.Nodes)
            {
                if (SearchNode.Tag == TreeTag)
                {
                    SearchNode.Expand();
                    _MethodPropertyFieldTreeView.SelectedNode = SearchNode;

                    _Parent.SelectMethodPropertyFieldTreeNode();

                    return SearchNode;
                }
            }

            return null;
        }

        private TreeNode FindPropertyNode(TreeView Tree, Property TreeTag)
        {
            foreach (TreeNode SearchNode in Tree.Nodes)
            {
                if (SearchNode.Tag == TreeTag)
                {
                    SearchNode.Expand();
                    _MethodPropertyFieldTreeView.SelectedNode = SearchNode;

                    _Parent.SelectMethodPropertyFieldTreeNode();

                    return SearchNode;
                }
            }

            return null;
        }

        private TreeNode FindFieldNode(TreeView Tree, Field TreeTag)
        {
            foreach (TreeNode SearchNode in Tree.Nodes)
            {
                if (SearchNode.Tag == TreeTag)
                {
                    SearchNode.Expand();
                    _MethodPropertyFieldTreeView.SelectedNode = SearchNode;

                    _Parent.SelectMethodPropertyFieldTreeNode();

                    return SearchNode;
                }
            }

            return null;
        }

        private void tvwResults_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode Node = e.Node;
            TreeNode FoundNode = null;
            Object NodeTag = Node.Tag;
            Library LibraryTag = null;
            Class ClassTag = null;
            Annotation AnnotationTag = null;
            Method MethodTag = null;
            Parameter ParameterTag = null;
            Property PropertyTag = null;
            Field FieldTag = null;

            // Depending on what type of node has been double-clicked, we have to do different things
            switch (NodeTag.GetType().Name)
            {
                case "Library":
                    LibraryTag = (Library)NodeTag;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    break;
                case "Class":
                    ClassTag = (Class)NodeTag;
                    LibraryTag = (Library)ClassTag.Parent;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    FoundNode = FindClassNode(FoundNode, ClassTag);
                    break;
                case "Method":
                    MethodTag = (Method)NodeTag;
                    ClassTag = (Class)MethodTag.Parent;
                    LibraryTag = (Library)ClassTag.Parent;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    FoundNode = FindClassNode(FoundNode, ClassTag);
                    FoundNode = FindMethodNode(_MethodPropertyFieldTreeView, MethodTag);
                    break;
                case "Annotation":
                    AnnotationTag = (Annotation)NodeTag;
                    ClassTag = (Class)AnnotationTag.Parent;
                    LibraryTag = (Library)ClassTag.Parent;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    FoundNode = FindClassNode(FoundNode, ClassTag);
                    break;
                case "Parameter":
                    ParameterTag = (Parameter)NodeTag;
                    MethodTag = (Method)ParameterTag.Parent;
                    ClassTag = (Class)MethodTag.Parent;
                    LibraryTag = (Library)ClassTag.Parent;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    FoundNode = FindClassNode(FoundNode, ClassTag);
                    FoundNode = FindMethodNode(_MethodPropertyFieldTreeView, MethodTag);
                    break;
                case "Property":
                    PropertyTag = (Property)NodeTag;
                    ClassTag = (Class)PropertyTag.Parent;
                    LibraryTag = (Library)ClassTag.Parent;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    FoundNode = FindClassNode(FoundNode, ClassTag);
                    FoundNode = FindPropertyNode(_MethodPropertyFieldTreeView, PropertyTag);
                    break;
                case "Field":
                    FieldTag = (Field)NodeTag;
                    ClassTag = (Class)FieldTag.Parent;
                    LibraryTag = (Library)ClassTag.Parent;
                    FoundNode = FindLibraryNode(_LibraryClassTreeView, LibraryTag);
                    FoundNode = FindClassNode(FoundNode, ClassTag);
                    FoundNode = FindFieldNode(_MethodPropertyFieldTreeView, FieldTag);
                    break;
            }
        }

    }
}
