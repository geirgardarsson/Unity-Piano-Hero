import midi
import json
import argparse
from collections import defaultdict


parser = argparse.ArgumentParser()
parser.add_argument('midi_file')

args = parser.parse_args()

song = midi.read_midifile(args.midi_file)
song.make_ticks_abs()


tracks = []


for track in song:

    notes = []
    open_notes = defaultdict(int)

    for note in track:

        if note.name == 'Note On':
            open_notes[note.pitch] = note.tick

        elif note.name == 'Note Off':
            notes.append({
                'notenumber': note.pitch,
                'start': open_notes[note.pitch],
                'end': note.tick
            })

            open_notes.pop(note.pitch)

        else:
            pass

    if len(notes) > 0:
        notes.sort(key=lambda a: a['start'])
        tracks.append({'notes': notes})


json_song = {
    'name': args.midi_file.split('.')[0],
    'tracks': tracks
}


for info in song[0]:
    if info.name == "Set Tempo":
        json_song["tempo"] = int(info.get_bpm())

location = '../../Resources/Json/'

with open(location + args.midi_file.split('.')[0] + '.json', "w") as outfile:
    json.dump(json_song, outfile)


