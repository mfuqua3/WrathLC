import {Stack, TextField} from "@mui/material";
import {FieldHookConfig, useField} from "formik";
import React, {useState} from "react";
import {DesktopDatePicker} from "@mui/lab";
import moment from "moment";

interface OtherProps {
    label: string;
    format?: moment.LongDateFormatKey;
    dateOnly?: boolean;
    stackDirection?: "row" | "row-reverse" | "column" | "column-reverse"
}

const FormikDateTimePicker = (props: OtherProps & FieldHookConfig<string>): JSX.Element => {
    const [field, meta, helpers] = useField(props);
    const [timestamp, setTimestamp] = useState<string | null>(moment(field.value).format("LT"));

    function onTimestampChanged(value: string) {
        setTimestamp(value);
        const time = moment("0001-01-01 " + value);
        if (time.isValid()) {
            const dateTime = moment(field.value).hour(time.hour()).minute(time.minute()).second(0);
            helpers.setValue(dateTime.format(props.format));
        }
    }

    function onDateChanged(value: Date | null) {
        if (value) {
            const dateMoment = moment(value);
            const dateTime = moment(field.value).set({
                "year": dateMoment.year(),
                "month": dateMoment.month(),
                "date": dateMoment.date()
            });
            helpers.setValue(dateTime.format(props.format));
        }

    }

    return (
        <Stack direction={props.stackDirection ?? "row"} spacing={1}>
            <DesktopDatePicker
                {...field}
                value={moment(field.value).toDate()}
                onChange={onDateChanged}
                label={props.label}
                renderInput={(params: object) => <TextField
                    fullWidth
                    variant="outlined"
                    error={meta.touched && Boolean(meta.error)}
                    helperText={meta.touched && meta.error} {...params}/>}/>
            {
                !props.dateOnly && <TextField
                    placeholder={"12:00 PM"}
                    fullWidth
                    value={timestamp}
                    error={!moment("1991-01-26 " + timestamp).isValid()}
                    onChange={(e) => onTimestampChanged(e.target.value)}
                    variant={"outlined"}>

                </TextField>
            }
        </Stack>

    );
};

export default React.memo(FormikDateTimePicker);
