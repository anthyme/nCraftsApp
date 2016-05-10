module Core

open FSharp.Data
open Newtonsoft.Json
open System.IO
open System.Text.RegularExpressions
open NCrafts.App.Business.Common.JsonSerializer.Data

let sessionUrl = "http://ncrafts.io/api/sessions.json"
type Sessions = JsonProvider<"""[{
        "id": "nc16-cth01",
        "event": "ncrafts2016",
        "format": "keynote",
        "durationMinutes": 60,
        "startTime": "2016-05-13T15:00Z",
        "room": "keynote",
        "title": "A Hundred Times....",
        "abstract": "Gently make haste, of Labour not afraid;\nA hundred times consider what you've said:\nPolish, repolish, every Colour lay,\nAnd sometimes add; but oft'ner take away.\nBoileau -  Art Poétique\n\nIt's mainstream nowadays: everyone is Agile. But what does it mean to be Agile? It means opting for direct communication and collaboration, embracing change, striving for simplicity.. It also means fostering technical excellence, lest agile become fragile.\n\nNow, to cultivate excellence, and respond in a better way to the customer's constraints and requests, we must learn. Learn about what? About that which schools -- engineering and other schools -- do not teach: we must learn our developer craft. This is where the fashion of the day disappears, and the old habits reappear. At work, one learns very slowly, and lessons, inasmuch as one is ready to listen to them, are expensive. Besides, the goal is not to learn, but to make. \n\nAnd yet, where else could we be learning? Not in school, not in one's room, but on our project, with our team, everyday. Why is it difficult? There's no shortage of information.  After all, do you know any development practice that isn't fully described on the internet?\n\n \nBut in the workplace the mental models -- not to mention prejudices -- die hard: specialization, individual performance, process:  IT work is a factory!\n\nThe fact that our projects, agile or not, invariably end up being rushed and dashed, thus stopping us from taking the time to learn and get better at our craft, is undoubtedly the most remarkable irony of this industry. It's the same old story of the developers not having time to test their code, having all those bugs to fix! \n\nLearning to progress in a continuous way with our team is both simple and difficult. Simple, because agreed-upon standard practices have been there ever since there were development teams. These practices are easy to put in place. And the difficult thing is that you have to decide to so first. And why is that hard?  Because a change of models is necessary:  these practices are not focused on process, tasks, roles, but on feedback, on the diffusion of know-how, and cultivating social skills. Farewell software `factory`!\n\nIn this keynote, I will throw flares on the path of excellence, sharing about what I have been observing in the developer trade for more than two decades.",
        "tags": [
            "Life",
            "Craftsmanship",
            "Practices"
        ],
        "cospeakers": [{
                "name": "Jean Helou",
                "link": "/speaker/jeanhelou",
                "id": null
            },
            {
                "name": "Clement Bouillier",
                "link": "/speaker/clem_bouillier",
                "id": null
            }]
    }]""">

let speakerUrl = "http://ncrafts.io/api/speakers.json"
type Speakers = JsonProvider<"http://ncrafts.io/api/speakers.json">
type FindSpeakerBySessionId = string[] -> string -> Speakers.Root option
type FindSpeakerByName = string -> Speakers.Root option

let save path json = File.WriteAllText (path, json)

let isSpeakerName (speaker:Speakers.Root) (name:string) = name.ToLower().Contains(speaker.FirstName.ToLower()) && name.ToLower().Contains(speaker.LastName.ToLower())


let mapSession (findSpeakerBySessionId:FindSpeakerBySessionId) (findSpeakerByName:FindSpeakerByName) (session:Sessions.Root) =
    let mapped = new SessionModel()
    mapped.Details             <- session.Abstract
    mapped.Id                   <- session.Id
    mapped.Place                <- session.Room
    mapped.Tags                 <- session.Tags
    mapped.Title                <- session.Title
    mapped.Type                 <- session.Format
    let cospeakerNames = (if session.Cospeakers <> null then (session.Cospeakers |> Array.map (fun x -> x.Name)) else [||])
    let speaker = (findSpeakerBySessionId cospeakerNames session.Id)
    let coSpeakers = cospeakerNames |> Seq.filter (fun x->not (isSpeakerName (speaker.Value) x)) |> Seq.map findSpeakerByName |> List.ofSeq
    let speakers = [speaker] @ coSpeakers |> List.choose id |> List.map (fun x -> x.Id)
    mapped.SpeakersId <- new ResizeArray<string>(speakers)

    mapped.StartTime <- match session.Id with 
                        | "nc16-jcl01" -> "2016-05-12T13:45:00.0000000Z"
                        | "nc16-jmo01" -> "2016-05-13T09:45:00.0000000Z"
                        | "nc16-hfa01" -> "2016-05-13T13:45:00.0000000Z"
                        | _ -> session.StartTime.ToString("o")

    mapped.DurationInMinutes <- match session.Id with
                                | "nc16-sma01" -> 45
                                | "nc16-lke01" -> 45
                                | "nc16-gyo02" -> 105
                                | _ -> session.DurationMinutes
    mapped

let mapSpeakerSession (findSpeakerBySessionId:FindSpeakerBySessionId) (session:Speakers.Session) = 
    let mapped = new SessionModel()
    mapped.Details             <- session.Abstract
    mapped.DurationInMinutes   <- session.DurationMinutes
    mapped.Id                   <- session.Id
//    mapped.Place                <- session.??
    let cospeakerNames = (if session.Cospeakers <> null then (session.Cospeakers |> Array.map (fun x -> x.Name)) else [||]) 
    mapped.SpeakersId <- new ResizeArray<string>(match (findSpeakerBySessionId cospeakerNames session.Id) with | Some x  -> [x.Id] | _ -> [])
    mapped.StartTime <- match session.StartTime with | Some date -> date.ToString() | None -> null
    mapped.Tags                 <- session.Tags
    mapped.Title                <- session.Title
//    mapped.Type                 <- session.??
    mapped

let mapGithub rawGithub = 
    let (|Name|ApiPage|None|) (input:string) =
        let name = Regex.Match(input, @"^([0-9a-zA-Z]+)$") 
        let accountPage = Regex.Match(input, @"^https:\/\/github.com\/([0-9a-zA-Z]+)$")
        let apiPage =  Regex.Match(input, @"^https:\/\/api.github.com\/user\/(\d+)$") 
        
        if (name.Success)               then Name (string name.Groups.[1])
        else if (accountPage.Success)   then Name (string accountPage.Groups.[1])
        else if (apiPage.Success)       then ApiPage (string apiPage.Groups.[1])
        else None

    let getGithubLogin = function
        | "216452" -> "Morendil"
        | "351773" -> "jak78"
        | id -> 
            printfn "%s" id
            failwith "Unknown github id, please go to https://api.github.com/users/" + id

    match rawGithub with
    | Some (Name name) -> name
    | Some (ApiPage id) -> getGithubLogin id
    | _ -> null

let mapPicture rawPicture =
    let result = Regex.Match(rawPicture, @"^.*(speakers\/[0-9a-zA-Zé_-]+\.(jpe?g|png))$")
    if (result.Success) then "http://ncrafts.io/" + (string result.Groups.[1])
    else null

let mapSpeaker  (findSpeaker:FindSpeakerBySessionId) (speaker:Speakers.Root) =
    let mapped = new SpeakerModel()
    mapped.Avatar           <- new AvatarModel()
    mapped.Avatar.IconBig   <- mapPicture speaker.Photo
    mapped.Avatar.IconSmall <- mapPicture speaker.Photo
//    mapped.Books        <- speaker.??
    mapped.Company      <- match speaker.Company with | Some x -> x | None -> null
    mapped.Id           <- speaker.Id
    mapped.Github       <- mapGithub speaker.Github 
    mapped.Details      <- speaker.Bio
    mapped.Languages    <- new ResizeArray<string>(speaker.Languages.Strings)
    mapped.FirstName    <- speaker.FirstName 
    mapped.LastName     <- speaker.LastName
    mapped.SessionsId   <- new ResizeArray<string>(speaker.Sessions |> Seq.map (mapSpeakerSession findSpeaker) |> Seq.map (fun x -> x.Id))
    mapped.Site         <- match speaker.Site with | Some x -> x | None -> null 
//    mapped.Slides       <- speaker.??
    mapped.Twitter      <- speaker.Twitter
    mapped


let findSpeakerBySessionId (speakers:Speakers.Root[]) (cospeakerNames:string[]) (sessionId:string) =
    let isACoSpeaker (speaker:Speakers.Root) (cospeakerNames:string[]) = cospeakerNames |> Seq.exists (isSpeakerName speaker)
    let isSpeakerSession (speaker:Speakers.Root) = (not (isACoSpeaker speaker cospeakerNames)) && (speaker.Sessions |> Seq.exists (fun x -> x.Id = sessionId))
    speakers |> Seq.tryFind isSpeakerSession


let findSpeakerByName (speakers:Speakers.Root[]) (speakerName:string) = speakers |> Seq.tryFind (fun speaker -> isSpeakerName speaker speakerName)

let extractSessions findSpeakerBySessionId findSpeakerByName =
    Sessions.Load(sessionUrl)
    |> Seq.map (mapSession findSpeakerBySessionId findSpeakerByName)
    |> JsonConvert.SerializeObject
    |> save "sessions.json"

let extractSpeakers findSpeaker =
    Speakers.Load(speakerUrl)
    |> Seq.map (mapSpeaker findSpeaker)
    |> JsonConvert.SerializeObject
    |> save "speakers.json"

let extractData() =
    let sessions = Sessions.Load(sessionUrl)
    let speakers = Speakers.Load(speakerUrl)
    let findSpeakerBySessionId' = findSpeakerBySessionId speakers
    extractSessions findSpeakerBySessionId' (findSpeakerByName speakers)
    extractSpeakers findSpeakerBySessionId'
