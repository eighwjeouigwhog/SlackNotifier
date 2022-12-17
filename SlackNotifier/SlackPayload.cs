namespace Slack
{

    public class Block
    {
        virtual public string type { get; set; }
    }

    public class SObject
    {
        virtual public string type { get; set; }

    }

    public class Text : SObject
    {
        override public string type { get; set; }

        public string text;
        public Text(string typeArg, string textArg)
        {
            type = typeArg;
            text = textArg;
        }
        public Text(string textArg)
        {
            type = "plain_text";
            text = textArg;
        }
    }

    public class Context : Block
    {
        override public string type { get; set; }
        public SObject[] elements { get; set; }
        public Context(SObject[] elms)
        {
            type = "context";
            elements = elms;
        }
    }

    public class Payload
    {
        public string channel;
        public string username;
        public string text;
        public string icon_emoji;
        public string icon_url;
        public Attachment[] attachments;
        public Block[] blocks;
        public string mrkdwn = "true";
    }

    public sealed class Attachment
    {
        public string fallback;
        public string color;
        public string pretext;
        public string author_name;
        public string author_link;
        public string author_icon;
        public string title;
        public string title_link;
        public string text;
        public Field[] fields;
        public string image_url;
        public string thumb_url;
        public string footer;
        public string footer_icon;
        public string ts;
        public string[] mrkdwn_in;
    }

    public sealed class Field
    {
        public string title;
        public string value;
        public string @short;
    }


}
