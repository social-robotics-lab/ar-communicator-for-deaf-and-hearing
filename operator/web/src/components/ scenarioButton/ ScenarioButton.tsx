import { CSSProperties, useState } from "react";
import "./ScenarioButton.css"

const ScenarioButton:React.FC<{scenario:string}>=({scenario})=>{
    const [styleCheckMark,setStyleCheckMark]=useState<CSSProperties>({color:"#d7d7d7"});

    const handleClick=():void=>{
        const styleDone:CSSProperties={color:"#12d744"};  
        setStyleCheckMark(styleDone); 
    };
    
    return(
        <div id="scenarioButton">
            <span style={styleCheckMark}>
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
                    {/* <!--!Font Awesome Free 6.5.2 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.--> */}
                    <path fill="currentColor" d="M438.6 105.4c12.5 12.5 12.5 32.8 0 45.3l-256 256c-12.5 12.5-32.8 12.5-45.3 0l-128-128c-12.5-12.5-12.5-32.8 0-45.3s32.8-12.5 45.3 0L160 338.7 393.4 105.4c12.5-12.5 32.8-12.5 45.3 0z"/>
                </svg>
            </span>
            <button onClick={handleClick}>
                {scenario}
            </button>
        </div>
    )
};

export default ScenarioButton;