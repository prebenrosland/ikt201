using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment_4.Models;

public class BlogPost
{
    public BlogPost(){}

    public BlogPost(string title, string content, string summary, string timestamp, string nickname)
    {
        Title = title;
        Content = content;
        Summary = summary;
        Timestamp = timestamp;
        Nickname = nickname;
    }
    
    public int Id { get; set; }

    [DisplayName("Title")]
    public string Title { get; set; }
    
    [DisplayName("Content")]
    public string Content { get; set; }
    
    [DisplayName("Summary")]
    public string Summary { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayName("Timestamp")]
    public string Timestamp { get; set; }
    
    public string Author { get; set; }
    
    public string Nickname { get; set; }
}