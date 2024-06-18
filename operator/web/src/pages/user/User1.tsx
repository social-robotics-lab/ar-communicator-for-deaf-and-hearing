import "./User.css"
import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";
import { useContext } from "react";
import { UsersInfoContext } from "../../providers/UsersInfoProvider";
import InputScenarioFileForm from "../../components/inputScenarioFileForm/InputScenarioFileForm";

const User1:React.FC=()=>{
    const {usersInfo}=useContext(UsersInfoContext);
    return(
        <div className="user">
            <UserHeader userIndex={1} isDHH={usersInfo.user1.isDHH} />
            <InputScenarioFileForm />
            <div>
                <ScenarioButton userKey="user1" scenario="シナリオ１−１" />
            </div>
        </div>
    )
};

export default User1;