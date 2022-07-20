open Giraffe.ViewEngine

type Repo = {
    name : string
    lang : string
}

let myFunReposList = [
    { name = "MyFunRepos";             lang = "F#" }
    { name = "FStarHelloWorld";        lang = "F*" }
    { name = "LambdaCalculusFSharp";   lang = "F#" }
    { name = "AsmToDelegate";          lang = "C#" }
]

html [] [
    body [] [
        h1 [] [ Text "My Fun Repos" ]
        ul [] [
            for { name = name; lang = lang } in myFunReposList do
                li [] [
                    p [] [ Text $"Repo {name}" ]
                    a [_href $"https://github.com/WhiteBlackGoose/{name}"] [ Text name ]
                    p [] [
                        Text "Made in "
                        if lang = "F#" || lang = "C#" then
                            Text $".NET {lang}"
                        else
                            Text lang
                    ]
                ]
        ]        
    ]
]
|> RenderView.AsString.htmlNode
|> fun code -> System.IO.File.WriteAllText("./index.html",  code)
