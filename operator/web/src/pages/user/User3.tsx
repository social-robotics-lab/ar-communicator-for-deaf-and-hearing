import { useContext, useState } from "react";
import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";
import { UsersInfoContext } from "../../providers/UsersInfoProvider";
import InputScenarioFileForm, { ScenarioListType } from "../../components/inputScenarioFileForm/InputScenarioFileForm";

const User3:React.FC=()=>{
    const {usersInfo}=useContext(UsersInfoContext);
    const [scenarioList,setScenarioList]=useState<ScenarioListType>();
    return(
        <div className="user">
            <UserHeader userIndex={3} isDHH={usersInfo.user3.isDHH} />
            <InputScenarioFileForm setScenarioList={setScenarioList} />
            <div>
                {scenarioList?.map((scenario,index)=>{
                    return (
                    <span key={index}>
                        {scenario.user===3?
                            <ScenarioButton userKey="user3" scenario={scenario.message} />
                            :<div className="otherMessage">
                                <span className="otherData">user{scenario.user}</span>
                                <span className="otherData">{scenario.message}</span>
                            </div>}
                    </span>
                    )
                })}
            </div>
        </div>
    )
};

export default User3;