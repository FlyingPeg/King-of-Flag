<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class Move extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return [
            'room_id' => $this->room_id,
            'step_w' => $this->step_w,
            'step_b' => $this->step_b,
        ];
    }
}
