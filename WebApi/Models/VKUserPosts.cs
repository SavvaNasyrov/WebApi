namespace PostsNamespace
{

    public class VKUsersPosts
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public Donut donut { get; set; }
        public Comments comments { get; set; }
        public float short_text_rate { get; set; }
        public string hash { get; set; }
        public string type { get; set; }
        public int carousel_offset { get; set; }
        public Attachment[] attachments { get; set; }
        public int date { get; set; }
        public int from_id { get; set; }
        public int id { get; set; }
        public Likes likes { get; set; }
        public int owner_id { get; set; }
        public Post_Source post_source { get; set; }
        public string post_type { get; set; }
        public Reposts reposts { get; set; }
        public string text { get; set; }
        public Views views { get; set; }
        public int edited { get; set; }
    }

    public class Donut
    {
        public bool is_donut { get; set; }
    }

    public class Comments
    {
        public int can_post { get; set; }
        public int count { get; set; }
        public bool groups_can_post { get; set; }
    }

    public class Likes
    {
        public int can_like { get; set; }
        public int count { get; set; }
        public int user_likes { get; set; }
        public int can_publish { get; set; }
        public bool repost_disabled { get; set; }
    }

    public class Post_Source
    {
        public string platform { get; set; }
        public string type { get; set; }
    }

    public class Reposts
    {
        public int count { get; set; }
        public int user_reposted { get; set; }
    }

    public class Views
    {
        public int count { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
    }

    public class Photo
    {
        public int album_id { get; set; }
        public int date { get; set; }
        public int id { get; set; }
        public int owner_id { get; set; }
        public string access_key { get; set; }
        public float lat { get; set; }
        public float _long { get; set; }
        public Size[] sizes { get; set; }
        public string text { get; set; }
        public bool has_tags { get; set; }
    }

    public class Size
    {
        public int height { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }


}
