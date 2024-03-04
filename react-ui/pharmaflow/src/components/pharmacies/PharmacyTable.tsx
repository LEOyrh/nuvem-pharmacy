import { useEffect, useState } from "react"
import { PharmacyDto } from "../../models/pharmacyDto"
import apiConnector from "../../api/apiConnector";
import { Button, Container } from "semantic-ui-react";
import PharmacyTableItem from "./PharmacyTableItem";
import { NavLink } from "react-router-dom";

interface PharmacyTableProps {
    searchTerm?: string;
}

export default function PharmacyTable({ searchTerm }: PharmacyTableProps) {

    // React Hook for api call
    const [pharmacies, setPharmacies] = useState<PharmacyDto[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const fetchedPharmacies = await apiConnector.getPharmacies();
            setPharmacies(fetchedPharmacies);
        }
        fetchData();
    }, []);

    const filteredPharmacies = pharmacies.filter(pharmacy =>
        pharmacy.pharmacyId!.toString().startsWith(searchTerm!.trim())
    );

    return (
        <>
            <Container>
                <table className="ui inverted table">
                    <thead style={{ textAlign: 'center' }}>
                        <tr>
                            <th>
                                Id
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Address
                            </th>
                            <th>
                                City
                            </th>
                            <th>
                                State
                            </th>
                            <th>
                                Zip
                            </th>
                            <th>
                                Filled Prescriptions
                            </th>
                            <th>
                                Created Date
                            </th>
                            <th>
                                Updated Date
                            </th>
                            <th>
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredPharmacies.length !== 0 && (
                            filteredPharmacies.map((pharmacy, index) => (
                                <PharmacyTableItem key={index} pharmacy={pharmacy} />
                            ))
                        )}
                    </tbody>
                </table>
                <Button as={NavLink} to="createPharmacy" floated="right" type="button" content="Create Pharmacy" positive />
            </Container>
        </>

    )
}