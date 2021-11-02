// Generate pages/literate.js file from pages/literate.fsx

#r "nuget: FSharp.Formatting"

open System.IO
open FSharp.Formatting.Literate

let eval = Evaluation.FsiEvaluator()

let innerHTML =
    let path = Path.Combine(__SOURCE_DIRECTORY__, "pages/literate.fsx")
    Literate.ParseAndCheckScriptFile(path, fsiEvaluator=eval)
    |> Literate.ToHtml

using (new FileStream(Path.Combine(__SOURCE_DIRECTORY__, "pages/literate.js"), FileMode.Create)) (fun fs ->
using (new StreamWriter(fs)) (fun writer ->

fprintfn writer """
import { createElement } from "react";

export function Literate() {
    return createElement("div", {
        dangerouslySetInnerHTML: {
            __html: `%s`,
        },
    });
};

export default Literate;
""" (innerHTML.Replace("`", "\\`"))

))
