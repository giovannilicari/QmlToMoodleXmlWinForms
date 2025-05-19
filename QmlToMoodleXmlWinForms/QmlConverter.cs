using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QmlToMoodleXmlWinForms
{
	public static class QmlConverter
    {
        public static void Convert(string qmlPath, string outputPath)
        {
            XDocument qmlDoc = XDocument.Load(qmlPath);
            XElement quiz = new XElement("quiz");

            foreach (var q in qmlDoc.Descendants("QUESTION"))
            {
                string qtype = q.Element("ANSWER")?.Attribute("QTYPE")?.Value;
                XElement xElement;

                if (qtype == "MC")
                {
                    xElement = QuestionTypes.MultipleChoice.Convert(q, true);
                }
                else if (qtype == "MR")
                {
                    xElement = QuestionTypes.MultipleChoice.Convert(q, false);
                }
                else if (qtype == "TF")
                {
                    xElement = QuestionTypes.TrueFalse.Convert(q);
                }
                else if (qtype == "OPEN")
                {
                    xElement = QuestionTypes.ShortAnswer.Convert(q);
                }
                else if (qtype == "NUM")
                {
                    xElement = QuestionTypes.Numerical.Convert(q);
                }
                else
                {
                    throw new Exception("Unsupported QTYPE: " + qtype);
                }

                XElement moodleQuestion = xElement;

                quiz.Add(moodleQuestion);
            }

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), quiz);
            doc.Save(outputPath);
        }
    }
}
