namespace VM
{
    public enum CommandType
    {
        Arithmetic, // e.g. all others (pop 2 args)
        Memory // push, pop (require segment and index args)
        /*,
         * Label,
        Goto,
        If,
        Function,
        Return,
        Call*/
    }
}
