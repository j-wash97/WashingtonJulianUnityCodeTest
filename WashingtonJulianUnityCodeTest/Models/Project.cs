using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WashingtonJulianUnityCodeTest.Models
{
    //The model to be delivered to the view when the page is requested
    public class Project
    {
        //Info for the project
        public Info ProjInfo { get; set; }
        //An ordered collection of all sections of the article associated with the project
        public Article[] Sections { get; set; }
        //An ordered collection of all pieces of content associated with the articale
        public Content[] Contents { get; set; }
    }

    //A database schema for Made With Unity projects
    [Table("Projects")]
    public class Info
    {
        //A unique identifer for the project in the database
        public int ID { get; set; }
        //The project's title
        public String Title { get; set; }
        //The creator of the project
        public String Developer { get; set; }
    }

    //A database schema for the sections of the article associate with a project
    [Table("Sections")]
    public class Article
    {
        //A unique identifier for the order in which a section appears in the article
        public int ID { get; set; }
        //The identifier for the project that this article section is associated with
        public int ProjID { get; set; }
        //The title for the section
        public string SecTitle { get; set; }
        //The relative file path to the background image to the section (i.e. image.jpg)
        public string BackgroundImgPath { get; set; }
        //The value passed to the itok parameter when calling the background image (i.e. ?itok=[value])
        public string BckgrndImgToken { get; set; }
    }

    //An enumeration for the types of content that the application would handle
    public enum ContentType
    { Text, Image, Video, Link }

    //A database schema for the article contents associated with a project
    [Table("Contents")]
    public class Content
    {
        //A unique identifier for the order in which a piece of content appears in a section
        public int ID { get; set; }
        //The identifier for the project that this content is associated with
        public int ProjID { get; set; }
        //The identifier for the section that this content is associated with
        public int SecID { get; set; }
        //The content's type
        public ContentType Type { get; set; }
        /*The main content for a piece of content:
         *  The HTML content for Text
         *  The relative file path for an Image
         *  The tag for a Video
         *  The URL for a Link
         */
        public string Main { get; set; }
        /*The sub content for a piece of content:
        *  The header content for Text
        *  The caption for an Image
        *  The caption for a Video
        *  The text for a Link
        */
        public string Sub { get; set; }
        //The value passed to the itok parameter when calling an image (i.e. ?itok=[value]).  Used only in Image content
        public string ImgToken { get; set; }
    }

    //The application's context to the database of project data
    public class ProjectDBContext : DbContext
    {
        public DbSet<Info> Projects { get; set; }
        public DbSet<Article> Sections { get; set; }
        public DbSet<Content> Contents { get; set; }
    }
}