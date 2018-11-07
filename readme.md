# Century Link
# CodeChallenge 
-----------------------

Usage:

Get Followers:
GET:
url: http://localhost:53926/api/Followers/{githubID}

Get Repositories:
GET:
url: http://localhost:53926/api/Repo/{githubID}

Get Stargazers:
POST:
url: http://localhost:53926/api/Stargazers/{githubID}
Body: 
[
	{
	"Repo": "{repositoryNameGoesHere}"
	}
]
