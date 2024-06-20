import { getScenarioJson } from "./getScenarioJson";
import "./InputScenarioFileForm.css"

export type ScenarioListType=Array<{user:number,message:string}>;

const InputScenarioFileForm:React.FC<{setScenarioList(data:ScenarioListType):void}>=({setScenarioList})=>{
    const handleInputChange=(e:any)=>{
        const file=e.target.files[0];
        (async()=>{
            const scenarioJson= await getScenarioJson(file);
            const scenarioList:ScenarioListType=scenarioJson.slice(1).map((row)=>{
                return { user:Number(row[1]), message:String(row[2])}
            });
            setScenarioList(scenarioList);
        })();
    }
    return(
        <div id="inputScenario">
            <label>シナリオファイル</label>
            <input type="file" accept=".csv" onChange={handleInputChange} />
        </div>
    )
};

export default InputScenarioFileForm;