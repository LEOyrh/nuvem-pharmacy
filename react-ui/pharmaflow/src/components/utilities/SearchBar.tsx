import React, { useState, useEffect } from 'react';
import { Input } from 'semantic-ui-react';

interface SearchBarProps {
    onSearch: (searchTerm: string) => void;
}

export const SearchBar: React.FC<SearchBarProps> = ({ onSearch }) => {
    const [searchTerm, setSearchTerm] = useState('');

    useEffect(() => {
        onSearch(searchTerm);
    }, [searchTerm, onSearch]);

    return (
        <Input
            icon='search'
            placeholder='Search Pharmacy By Id...'
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            style={{ marginBottom: '20px' }}
        />
    );
};