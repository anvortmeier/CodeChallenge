# Century Link
# CodeChallenge 
-----------------------

Usage:

Get Followers:
GET:
url: http://localhost:53926/api/Followers/{githubId}
parameter: github user ID

Get Repositories:
GET:
url: http://localhost:53926/api/Repo/{githubId}

Get Stargazers:
POST:
url: http://localhost:53926/api/Stargazers/{githubId}
Body: 
[
	{
	"Repo": "{repositoryNameGoesHere}"
	}
]
