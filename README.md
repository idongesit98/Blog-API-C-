# Blog-Api
This project is a Sample solution for the [Blog-Platform-Api](https://roadmap.sh/projects/blogging-platform-api) challenge from [roadmap.sh](https://roadmap.sh/),it allows users of the Api to be able create,read,delete and update posts on the blog.

## Features
- **Create Blog Posts**: Add new blog posts with title, content, category, and tags.
- **Update Blog Posts**: Modify existing blog posts with new information.
- **Delete Blog Posts**: Remove blog posts from the platform.
- **View Blog Posts**: Retrieve single or multiple blog posts.
- **Search Blog Posts**: Filter posts by a search term in the title, content, or category.


## 🚀 Getting Started

To clone the project you need the following below:

### Prerequisites
- .NET 8.0 and above
- MySQL
- Git

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/idongesit98/Blog-Api.git
   cd blogging-platform-api
   ```

2. Install dependencies:
   ```bash
   dotnet build
   ```
3. Start the development server:
   ```bash
   dotnet run
   ```

# API Endpoints
## Blog
- POST /api/blog/posts
- PUT /api/blog/post-update/:id
- DELETE /api/blog/:id
- GET /api/blog/all-posts
- GET /api/blog/search


