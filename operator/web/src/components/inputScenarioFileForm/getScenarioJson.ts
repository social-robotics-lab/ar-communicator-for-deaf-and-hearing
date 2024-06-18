import Papa from "papaparse";

export const getScenarioJson=(file:any)=>{
    Papa.parse(file,{
        complete: function(results) {
            console.log("Finished:", results.data);
        }
    });
    // console.log(results)
};