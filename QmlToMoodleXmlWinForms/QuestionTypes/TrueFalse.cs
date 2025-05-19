using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QmlToMoodleXmlWinForms.QuestionTypes
{
	public static class TrueFalse
	{
		public static XElement Convert(XElement qmlQuestion)
		{
			XElement question = new XElement("question", new XAttribute("type", "truefalse"));
			question.Add(new XElement("name", new XElement("text", qmlQuestion.Attribute("DESCRIPTION")?.Value)));
			question.Add(new XElement("questiontext", new XAttribute("format", "html"),
				new XElement("text", qmlQuestion.Element("CONTENT")?.Value ?? "")));
			question.Add(new XElement("generalfeedback", new XAttribute("format", "html"), new XElement("text", "")));

			string correct = qmlQuestion.Element("OUTCOME")?.Element("CONDITION")?.Value.Trim('"');
			question.Add(CreateAnswer("true", correct == "true"));
			question.Add(CreateAnswer("false", correct == "false"));
			return question;
		}

		private static XElement CreateAnswer(string text, bool isCorrect)
		{
			return new XElement("answer", new XAttribute("fraction", isCorrect ? "100" : "0"),
				new XElement("text", text),
				new XElement("feedback", new XElement("text", isCorrect ? "Vero" : "Falso"))
			);
		}
	}
}
