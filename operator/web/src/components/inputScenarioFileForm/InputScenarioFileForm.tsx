import { getScenarioJson } from "./getScenarioJson";
import "./InputScenarioFileForm.css"

const InputScenarioFileForm:React.FC=()=>{
    const handleInputChange=(e:any)=>{
        const file=e.target.files[0];
        getScenarioJson(file);
    }
    return(
        <div id="inputScenario">
            <label>シナリオファイル</label>
            <input type="file" accept=".csv" onChange={handleInputChange} />
        </div>
    )
};

export default InputScenarioFileForm;