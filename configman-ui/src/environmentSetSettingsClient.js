import SettingsClient from "./settingsClient";

class EnvironmentSetSettingsClient extends SettingsClient {
    async getEnvironmentSet(name) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${name}`, {
            headers: this.getHeaders(),
        });
        return this.handleResponse(response);
    }

    async getEnvironmentSets() {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets`, {
            headers: this.getHeaders(),
        });

        return this.handleResponse(response);
    }

    async getEnvironmentSetToApplicationAssociation(environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/EnvironmentSetApplicationAssociation/${environmentSetId}`, {
            headers: this.getHeaders(),
        });

        return this.handleResponse(response);
    }

    async getHistory(environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSetHistory/${environmentSetId}`, {
            headers: this.getHeaders(),
        });
        return this.handleResponse(response);
    }
    
    async renameEnvironmentSet(environmentSetId, version, newName) {
        console.log("Renaming", newName);
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}/rename`, {
            method: 'PUT',
            headers: this.getHeaders(version),
            body: JSON.stringify(newName),
        });
        return this.handleResponse(response);
    }

    async renameEnvironment(environmentSetId, version, oldValue,newValue) {
        console.log("Renaming", oldValue, "to", newValue, "with version", version);
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}/environment/${oldValue}/rename`, {
            method: 'PUT',
            headers: this.getHeaders(version),
            body: JSON.stringify(newValue),
        });
        return this.handleResponse(response);
    }

    async deleteEnvironmentSet(environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}`, {
            method: 'DELETE',
            headers: this.getHeaders(),
        });

        return this.handleResponse(response);
    }

    async deleteEnvironment(envrionmentSetId, environment) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${envrionmentSetId}/environment/${environment}`, {
            method: 'DELETE',
            headers: this.getHeaders(),
        });

        return this.handleResponse(response);
    }

    async addEnvironmentSet(environmentName) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets`, {
            method: 'POST',
            headers: this.getHeaders(),
            body: JSON.stringify({ name: environmentName }),
        });
        return this.handleResponse(response);
    }

    async addEnvironmentToEnvironmentSet(environmentName, environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}/environment`, {
            method: 'POST',
            headers: this.getHeaders(),
            body: JSON.stringify(environmentName),
        });
        return this.handleResponse(response);
    }

    async addVariableToEnvironmentSet(variableName, environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}/variable`, {
            method: 'POST',
            headers: this.getHeaders(),
            body: JSON.stringify(variableName),
        });
        return this.handleResponse(response);
    }

    async updateVariableOnEnvironmentSet(environment, variableName, newValue, environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}/variable/${environment}/${variableName}`, {
            method: 'PUT',
            headers: this.getHeaders(),
            body: JSON.stringify(newValue),
        });
        return this.handleResponse(response);
    }

    async renameVariableOnEnvironmentSet(originalName, newName, environmentSetId) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSetId}/variable/${originalName}/rename`, {
            method: 'PUT',
            headers: this.getHeaders(),
            body: JSON.stringify(newName),
        });
        return this.handleResponse(response);
    }



    async updateEnvironmentSet(environmentSet) {
        const response = await this.apiRequest(`${this.apiUrl}/api/environmentSets/${environmentSet.name}`, {
            method: 'PUT',
            headers: this.getHeaders(),
            body: JSON.stringify(environmentSet),
        });

        return this.handleResponse(response);
    }
}

export default EnvironmentSetSettingsClient;