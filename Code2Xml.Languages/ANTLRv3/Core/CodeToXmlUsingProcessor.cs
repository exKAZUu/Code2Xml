using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using Code2Xml.Core;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.XmlToCodes;

namespace Code2Xml.Languages.ANTLRv3.Core {
    public abstract class CodeToXmlUsingProcessor<TProcessor, TXmlToCode> : CodeToXml
            where TProcessor : Processor, new()
            where TXmlToCode : XmlToCodeUsingProcessor<TProcessor>, new() {
        private readonly TProcessor _processor;
        private readonly TXmlToCode _xmlToCode;

        public TProcessor Processor {
            get { return _processor; }
        }

        public override string ParserName {
            get { return _processor.LanguageName + " " + _processor.LanguageVersion; }
        }

        public override ReadOnlyCollection<string> TargetExtensions {
            get { return _processor.SupportedExtensions; }
        }

        public override XmlToCode XmlToCode {
            get { return _xmlToCode; }
        }

        protected CodeToXmlUsingProcessor() {
            _processor = new TProcessor();
            _xmlToCode = new TXmlToCode();
        }

        public override XElement Generate(
                TextReader reader, bool throwingParseError = DefaultThrowingParseError,
                bool enablePosition = DefaultEnablePosition) {
            return _processor.GenerateXml(reader, throwingParseError);
        }
    }
}