import React, {DetailedHTMLProps, ImgHTMLAttributes} from "react";

type NoSourceImageProps = Omit<DetailedHTMLProps<ImgHTMLAttributes<HTMLImageElement>, HTMLImageElement>, "src" | "alt">

export interface ItemIconProps extends NoSourceImageProps{
    iconName: string,
}

function ItemIcon({iconName, ...props}: ItemIconProps) {
    return (
        <img src={`https://wow.zamimg.com/images/wow/icons/large/${iconName}.jpg`} alt={"?"} {...props}/>
    )
}

export default React.memo(ItemIcon);