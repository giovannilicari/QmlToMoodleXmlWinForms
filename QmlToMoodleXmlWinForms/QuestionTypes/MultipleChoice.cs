using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QmlToMoodleXmlWinForms.QuestionTypes
{
	public static class MultipleChoice
	{
		public static XElement Convert(XElement qmlQuestion, bool single)
		{
			XElement question = new XElement("question", new XAttribute("type", "multichoice"));
			question.Add(new XElement("name", new XElement("text", qmlQuestion.Attribute("DESCRIPTION")?.Value)));
			question.Add(new XElement("questiontext", new XAttribute("format", "html"),
				new XElement("text", qmlQuestion.Element("CONTENT")?.Value ?? "")));

			string correctId = qmlQuestion.Element("OUTCOME")?.Element("CONDITION")?.Value.Trim('"');
			foreach (var choice in qmlQuestion.Element("ANSWER")?.Elements("CHOICE"))
			{
				string id = choice.Attribute("ID")?.Value;
				string fraction = (id == correctId) ? "100" : "0";
				var answer = new XElement("answer", new XAttribute("fraction", fraction),
					new XElement("text", choice.Element("CONTENT")?.Value),
					new XElement("feedback", new XElement("text", fraction == "100" ? "Correct" : "Incorrect"))
				);
				question.Add(answer);
			}

			question.Add(new XElement("shuffleanswers", "1"));
			question.Add(new XElement("single", single ? "true" : "false"));
			question.Add(new XElement("answernumbering", "abc"));

			return question;
		}
	}
}
