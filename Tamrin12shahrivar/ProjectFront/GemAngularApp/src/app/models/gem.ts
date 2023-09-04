

export class Gem {
  gemId: string | null;
  data: string | null;
  weight: number|null;
  cutie: number|null;
  price: number|null;
  status: string | null;

  constructor(gemId: string | null = null, data: string | null = null, weight: number | null = null, cutie: number | null = null, price: number | null = null, status: string | null = null) {
    this.gemId = gemId,
      this.data = data,
      this.weight = weight,
      this.cutie = cutie,
      this.price = price,
      this.status = status
  }
}
