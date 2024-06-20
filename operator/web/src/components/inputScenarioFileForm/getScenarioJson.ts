import Papa from "papaparse";

type ScenarioJsonType=Array<Array<number|string>>;

export const getScenarioJson=(file:File)=>{
    return new Promise<ScenarioJsonType>((resolve, reject) => {
        Papa.parse(file, {
          complete: (results: any) => {
            resolve(results?.data);
          },
          error: () => {
            reject(new Error("csv parse err"));
          },
        });
      });
};