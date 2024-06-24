class RegionInfo {
    constructor( ) {
        const jsonData = `
        {
            "CurrentRegionIdx": 1,
            "Regions": [
                {
                    "$type": "DnsRegionInfo, Assembly-CSharp",
                    "Fqdn": "",
                    "DefaultIp": "",
                    "port": 22023,
                    "name": "North America",
                    "TranslateName": 289
                },
                {
                    "$type": "DnsRegionInfo, Assembly-CSharp",
                    "Fqdn": "",
                    "DefaultIp": "",
                    "port": 22023,
                    "name": "Europe",
                    "TranslateName": 290
                },
                {
                    "$type": "DnsRegionInfo, Assembly-CSharp",
                    "Fqdn": "",
                    "DefaultIp": "",
                    "port": 22023,
                    "name": "Asia",
                    "TranslateName": 291
                }
            ]
        }`;
        const data = JSON.parse(jsonData);
        Object.assign(this, data);
    }

    loadData(data) {
        Object.assign(this, data);
    }
}

export default RegionInfo;