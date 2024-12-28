import "./User.css"
import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";
import { useContext, useState } from "react";
import { UsersInfoContext } from "../../providers/UsersInfoProvider";
import InputScenarioFileForm, { ScenarioListType } from "../../components/inputScenarioFileForm/InputScenarioFileForm";

const User1:React.FC=()=>{
    const {usersInfo}=useContext(UsersInfoContext);
    const [scenarioList,setScenarioList]=useState<ScenarioListType>();

    return(
        <div className="user">
            <UserHeader userIndex={1} isDHH={usersInfo.user1.isDHH} />
            <InputScenarioFileForm setScenarioList={setScenarioList}/>
            <div>
                {scenarioList?.map((scenario,index)=>{
                    return (
                    <span key={index}>
                        {scenario.user===1?
                            <ScenarioButton userKey="user1" scenario={scenario.message} />
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

export default User1;