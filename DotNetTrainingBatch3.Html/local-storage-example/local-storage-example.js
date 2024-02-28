const tblBlog = "Tbl_Blog";

function runBlog()
{

}

function createBlog(title, author, content)
{
    const blog = 
    {
        Title : title,
        Author : author,
        Content : content
    }

    let jsonStr = JSON.stringify(blog);
    localStorage.setItem(tblBlog, blog);

}

function deleteBlog()
{

}

function editBlog()
{

}

