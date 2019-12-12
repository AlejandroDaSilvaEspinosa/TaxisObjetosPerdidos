import React from 'react';
export const FormErrors = ({ formErrors }) => {
    if (formErrors != undefined ) {
        return (
            <div>                
                <p style={{ color: 'red' }}> {formErrors}</p>
            </div>
        )
    }
    else return "";
};