using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QmlToMoodleXmlWinForms.QuestionTypes
{
	public static class Numerical
	{
		public static XElement Convert(XElement qmlQuestion)
		{
			XElement question = new XElement("question", new XAttribute("type", "numerical"));
			question.Add(new XElement("name", new XElement("text", qmlQuestion.Attribute("DESCRIPTION")?.Value)));
			question.Add(new XElement("questiontext", new XAttribute("format", "html"),
				new XElement("text", qmlQuestion.Element("CONTENT")?.Value ?? "")));
			question.Add(new XElement("generalfeedback", new XAttribute("format", "html"), new XElement("text", "")));

			string answer = qmlQuestion.Element("OUTCOME")?.Element("CONDITION")?.Value.Trim('"');
			var answerElem = new XElement("answer", new XAttribute("fraction", "100"),
				new XElement("text", answer),
				new XElement("tolerance", "0"),
				new XElement("feedback", new XElement("text", "Correct answer"))
			);
			question.Add(answerElem);
			question.Add(new XElement("units", new XElement("unit")));
			return question;
		}
	}
}
