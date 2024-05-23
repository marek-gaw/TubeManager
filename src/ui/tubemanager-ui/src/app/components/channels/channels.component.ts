import { Component } from '@angular/core';
import { ChannelsService } from '../../services/channels.service';
import { NgFor } from '@angular/common';
import { Channel } from '../../interfaces/channel';

@Component({
  selector: 'app-channels',
  standalone: true,
  imports: [
    NgFor
  ],
  templateUrl: './channels.component.html',
  styleUrl: './channels.component.css'
})
export class ChannelsComponent {

  channels: Channel[];
  editedChannel: Channel;

  constructor(private channelsService: ChannelsService) {
    this.channels = [];
    this.editedChannel = { id:"", name:"", channelId:"", description:"" };
  }

  ngOnInit(): void {
    this.getAllChannels();
  }

  getAllChannels(): void {
    this.channelsService.getAll().subscribe(data => {
      this.channels = data;
      console.log(data);
    })
  }

  onAddChannel(name: string, id: string): void {
    console.log(`onAddChannel:${name} | ${id}`);
    this.channelsService.create(name, id, "")
      .subscribe(channel => this.channels.push({
        id: channel.id,
        name: channel.name,
		channelId: channel.channelId,
		description: channel.description
      }));
  }

  onEditChannel(channel: Channel): void {
    console.log(`onEditChannel for channel: ${channel.id}|${channel.name}`);
    this.editedChannel = channel;
  }

  onSaveEditedChannel(id:string, name:string, channelId: string, description: string): void {
    console.log(`onSaveEditChannel for channel: ${id}|${name}`);
    this.channelsService.edit({id:id, name:name, channelId: channelId, description: description})
      .subscribe(channel => {
        const idx = this.channels.findIndex(o => o.id == channel.id);
        this.channels[idx] = channel;
      })
  }

  onDeleteChannel(channel: Channel): void {
    console.log(`onDeleteChannel for channel: ${channel.id} | ${channel.name}`);
    this.channelsService.delete(channel)
      .subscribe(t => {
        const idx = this.channels.indexOf(channel);
        this.channels.splice(idx, 1);
      })
  }
}
