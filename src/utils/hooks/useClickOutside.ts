/* eslint-disable */
/* tslint-disable */
import React, {useEffect, useState} from "react";

/*
Hook for detecting when a user clicks outside of a component.
to be used with a wrapper div around a component in which you want to perform an action on when the user clicks outside.
returns a boolean of the state of clicks outside of the component

use ClickOutsideWrapper to implement this in a wrapper component

ex: wrap around a custom modal to unmount when a user clicks outside of the modal
*/

function useClickOutside(ref: React.MutableRefObject<any>, isMounted: boolean): boolean[] {
    const [clicked, setClicked] = useState(false);

    useEffect(() => {

        function handleClickOutside(event: MouseEvent) {
            if (ref.current && !ref.current.contains(event.target) && isMounted) {
                setClicked(true);
            }
        }

        document.addEventListener("mousedown", handleClickOutside);
        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
            setClicked(false);
        };
    }, [ref, isMounted]);

    return [clicked];
}

export default useClickOutside;
