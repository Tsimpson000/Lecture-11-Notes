using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_11_Notes
{
    public class BlogPost
    {
        string _subjectLine;
        string _bodyText;
        Color _subjectColor;
        DateTime _timeStamp;

        public string SubjectLine { get => _subjectLine; set => _subjectLine = value; }
        public string BodyText { get => _bodyText; set => _bodyText = value; }

        public BlogPost(string subjectLine, string bodyText, Color userColor)
        {
            _subjectLine = subjectLine;
            _bodyText = bodyText;
            _subjectColor = userColor;
            _timeStamp = DateTime.Now;
        }

        public Run HeaderFormatted(string subjectLine)
        {
            Run headerRun = new Run(subjectLine);
            headerRun.Foreground = new SolidColorBrush(_subjectColor);
            headerRun.FontSize = 24;
            headerRun.FontStyle = FontStyles.Italic;
            return headerRun;
        }
        public Run BodyFormatted(string bodyText)
        {
            Run runNewBody = new Run(bodyText);

            runNewBody.FontSize = 14;

            return runNewBody;
        }
        public Paragraph BlogFormatted()
        {
            //Get the flow document,
            //Create Paragraph
            Paragraph newParagraph = new Paragraph();
            //Create a run
            string subjectLine = _subjectLine;
            string bodyText = _bodyText;
            Run header = HeaderFormatted(subjectLine);
            Run body = BodyFormatted(bodyText);

            //add to paragraph
            newParagraph.Inlines.Add(header);
            newParagraph.Inlines.Add("\n");
            newParagraph.Inlines.Add(body);

            return newParagraph;
        }

        public override string ToString()
        {
            return _timeStamp.ToShortTimeString() + " " + _subjectLine;
        }
    }
}
