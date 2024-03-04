import { Button } from "semantic-ui-react";
import { PharmacyDto } from "../../models/pharmacyDto";
import apiConnector from "../../api/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
    pharmacy: PharmacyDto;
}

export default function PharmacyTableItem({ pharmacy }: Props) {
    return (
        <>
            <tr className="center aligned">
                <td data-label="Id">{pharmacy.pharmacyId}</td>
                <td data-label="Name">{pharmacy.name}</td>
                <td data-label="Address">{pharmacy.address}</td>
                <td data-label="City">{pharmacy.city}</td>
                <td data-label="State">{pharmacy.state}</td>
                <td data-label="Zip">{pharmacy.zip}</td>
                <td data-label="FilledPrescriptions">{pharmacy.numberOfFilledPrescriptions}</td>
                <td data-label="CreatedDate">{new Date(pharmacy.createdDate).toLocaleDateString()}</td>
                <td data-label="UpdatedDate">{new Date(pharmacy.updatedDate).toLocaleDateString()}</td>
                <td data-label="Action">
                    <Button as={NavLink} to={`editPharmacy/${pharmacy.pharmacyId}`} color="yellow" type="submit">
                        Edit
                    </Button>
                    <Button type="button" negative onClick={async () => {
                        await apiConnector.deletePharmacy(pharmacy.pharmacyId!); // we will definitely have a pharmacy
                        window.location.reload();
                    }}>
                        Delete
                    </Button>
                </td>
            </tr >
        </>

    )
}