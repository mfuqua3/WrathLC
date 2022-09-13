import React, {DetailedHTMLProps, ImgHTMLAttributes} from "react";
import {WowClass} from "../../domain/utility-types";

type NoSourceImageProps = Omit<DetailedHTMLProps<ImgHTMLAttributes<HTMLImageElement>, HTMLImageElement>, "src" | "alt">

export interface ClassIconProps extends NoSourceImageProps{
    wowClass: WowClass,
}

function ClassIcon({wowClass, ...props}: ClassIconProps) {
    function getIconName() {
        switch (wowClass) {
            case "Death Knight":
                return "deathknight";
            default:
                return wowClass.toLowerCase();
        }
    }
    return (
        <img src={`/imgs/class-icon-${getIconName()}.webp`} alt={wowClass} {...props}/>
    )
}

export default React.memo(ClassIcon);