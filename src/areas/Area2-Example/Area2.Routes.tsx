import React from "react";
import {Route, Routes} from "react-router-dom";
import Area2 from "./Area2";

function Area2Routes() {
    return (
        <Routes>
            <Route index element={<Area2/>}/>
        </Routes>
    )

}

export default React.memo(Area2Routes);