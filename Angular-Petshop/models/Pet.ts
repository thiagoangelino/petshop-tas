export class Pet {
    
    constructor() {
        this.id = 0
        this.name = '';
        this.ownerName = '';
        this.ownerAddress = '';
        this.ownerPhone = '';
        this.cause = 0;
        this.accomodationPetId    = 0;
    }

    id: number;
    name: string;
    ownerName: string;
    ownerAddress: string;
    ownerPhone: string;
    cause: number;
    accomodationPetId: number;
}