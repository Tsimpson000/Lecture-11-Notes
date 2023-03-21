//What 's the difference between a paragraph and a run tag ( regarding space used )?

//run tag is one line vs paragraph is multiple

//What "Collection" does a Paragraph have that holds inlines?

//Run

//What "Collection" does a FlowDocument have that holds blocks?

//Paragraph

//How do you connect a FlowDocument to a RichTextBox

//rtbDisplay.Document = fdDisplay;

//How often does Will appear in the Rich Text Box with the following code? 

//once

//What property is used to add Italics?

//FontStyle

//What property is used to add bold?

//Font Weight

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lecture_11_Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //FlowDocument - first item
        //Paragraph - second item - block element
        //Run - third item - inline element

        FlowDocument fdDisplay = new FlowDocument();
        List<BlogPost> blogPosts = new List<BlogPost>();
        
        public MainWindow()
        {
            InitializeComponent();
            rtbDisplay.Document = fdDisplay;
            Paragraph para1 = new Paragraph();
            //creating a sentence
            Run run1 = new Run("Prog 122 - Advanced Rich Text Box");
            

            //adding it to paragraph
            para1.Inlines.Add(run1);

            //adding paragraph to document
            fdDisplay.Blocks.Add(para1);
            //add document to rich text box
            rtbDisplay.Document = fdDisplay;

        }//main window
        public void Example()
        {
            FlowDocument fdDisplay = new FlowDocument();
            Paragraph p = new Paragraph();
            Run r = new Run("Hi All");
            r.FontWeight = FontWeights.Bold;
            r.Foreground = new SolidColorBrush(Colors.DarkGray);
            r.FontSize = 22;

            p.Inlines.Add(r);
            fdDisplay.Blocks.Add(p);
            rtbDisplay.Document = fdDisplay;
        }

        private void btnDisplayInfo_Click(object sender, RoutedEventArgs e)
        {
            string subjectLine = txtSubjectLine.Text;
            string bodyText = runBody.Text;
            Color userColor = UsersColor();

            BlogPost bp = BlogPost(subjectLine, bodyText, userColor);
            blogPosts.Add(bp);
            //update display of blog posts
            DisplayBlogPosts();
            //add to flow document
            fdDisplay.Blocks.Add(blogPosts[0].BlogFormatted());
        }

        public void DisplayBlogPosts()
        {
            lbBlogPosts.Items.Clear();

            foreach (BlogPost item in blogPosts)
            {
                lbBlogPosts.Items.Add(item);
            }
        }

        private void lbBlogPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = lbBlogPosts.SelectedIndex;
            if(selected >= 0)
            {
                BlogPost bp = blogPosts[selected];
                UpdateRichTextBox(bp);
            }
        }
        public Color UsersColor()
        {
            byte r = byte.Parse(txtR.Text);
            byte g = byte.Parse(txtG.Text);
            byte b = byte.Parse(txtB.Text);
            Color userColor = Color.FromRgb(r, g, b);

            return userColor;
        }

        public void UpdateRichTextBox(BlogPost post)
        {
            fdDisplay.Blocks.Clear();
            fdDisplay.Blocks.Add(post.BlogFormatted());
        }
    }//class
}//Namespace
