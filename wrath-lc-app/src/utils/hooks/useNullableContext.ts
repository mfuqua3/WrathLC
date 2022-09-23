import React, {Context} from "react";

export function useNullableContext<S>(context: Context<S | null>, name: string) {
    const contextState = React.useContext(context)
    if(contextState === null){
        throw Error(`Invalid use of React context hook. Not called within a ${name} provider`);
    }
    return contextState;
}