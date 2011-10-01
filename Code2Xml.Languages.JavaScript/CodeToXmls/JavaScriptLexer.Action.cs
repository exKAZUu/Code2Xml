using Antlr.Runtime;

public partial class JavaScriptLexer {
    /// <summary>
    ///   Containts the last on channel token.
    /// </summary>
    protected IToken Last;

    /// <summary>
    ///   Indicates whether regular expression (yields true) or division expression recognition (false) in the lexer is enabled.
    ///   These are mutual exclusive and the decision which is active in the lexer is based on the previous on channel token.
    ///   When the previous token can be identified as a possible left operand for a division this results in false, otherwise true.
    /// </summary>
    private bool AreRegularExpressionsEnabled {
        get {
            if (Last == null) {
                return true;
            }

            switch (Last.Type) {
                // identifier
            case Identifier:
                // literals
            case NULL:
            case TRUE:
            case FALSE:
            case THIS:
            case NumericLiteral:
            case DecimalLiteral:
            case HexIntegerLiteral:
            case StringLiteral:
                // member access ending 
            case RBRACK:
                // function call or nested expression ending
            case RPAREN:
                return false;

                // otherwise OK
            default:
                return true;
            }
        }
    }

	/// <summary>
    ///   Override of base to track previous on channel token.
    ///   This token is needed as input to decide whether regular expression or division expression recognition is enabled.
    /// </summary>
    public override IToken NextToken() {
        var result = base.NextToken();
        if (result.Channel == DefaultTokenChannel) {
            Last = result;
        }
        return result;
    }
}