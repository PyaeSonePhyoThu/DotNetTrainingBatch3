const tblBlog = "Tbl_Blog";

function getBlogs()
{
    let lstBlogs = [];
    let blogStr = localStorage.getItem(tblBlog);
    if(blogStr != null)
    {
        lstBlogs = JSON.parse(blogStr);
    }
}
function runBlog()
{

}

function readBlog()
{
    var lstBlog = getBlogs();
    for (let i = 0; i < lstBlog.length; i++) {
        const item = lstBlog[i];
        console.log(item.Author);
        console.log(item.Content);
        console.log(item.Title);
    }
}

function createBlog(title, author, content)
{
    var lstBlog = getBlogs();

    const blog = 
    {
        Id : uuidv4(),
        Title : title,
        Author : author,
        Content : content
    }
    lstBlog.push(blog);
    let jsonStr = JSON.stringify(blog);
    localStorage.setItem(tblBlog, blog);
}

function update()
{
    let lstBlog = getBlogs();
    let lst = lstBlog.filter(x=> x.id === id);
    if(lst.length == 0)
    {
        console.log("No data found");
        return;
    }
}

function deleteBlog(id)
{
    let lstBlog = getBlogs();
    let lst = lstBlog.filter(x=> x.id === id);
    if(lst.length == 0)
    {
        console.log("No data found");
        return;
    }
    // let item = lst[0];
    // item.remove();
    lstBlog = lstBlog.filter(x=> x.id !== id);
    setLocalStorage(lstBlog);
}

function editBlog(id)
{
    let lstBlog = getBlogs();
    let lst = lstBlog.filter(x=> x.id === id); 
    if(lst.length == 0)
    {
        console.log("No data found.");
        return;
    }
    let item = lst[0];
    console.log(item);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
  }

function setLocalStorage(blog)
{
    let jsonStr = JSON.stringify(blog);
    localStorage.setItem(tblBlog, blog);
}